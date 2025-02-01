DateTime dateTime = DateTime.Now;
Document document = new Document();

bool restart = true;

while (restart) // PROGRAM START
{
Console.WriteLine("\r\n*** Welcome to the 'Sick Day Rule' Program ***");

// PATIENT DETAILS
string firstName = document.GetValidatedName("Enter your first name:");
string lastName = document.GetValidatedName("Enter your last name:");
long mrn = document.GetValidatedMRN("Enter your 7-digit MRN:");

Console.WriteLine($"\r\n[ Hi, {firstName} {lastName}; MRN: {mrn} ]\r\n");
Console.WriteLine("Produce your own tailored Sick Day Rule dosage according to your current steroid medication. Follow the prompts below and answer accordingly. \r\n");

// MEDICATION
// Store user-entered steroid medication to variable
char[] steroidMedOptions = { 'H', 'P' }; // Allowed options
char steroidMed = document.GetValidatedChoice("> What steroid medication are you on? Type H for Hydrocortisone, P for Prednisolone", steroidMedOptions);
string steroidMedStr = Convert.ToString(steroidMed);

// Medication Dose
// store user-entered steroid dose to variable
int steroidDose = document.GetValidatedNumber("> What daily dosage are you on? Enter number in mg");
Console.WriteLine(""); // spacer

// Display user-entered steroid medication
Console.WriteLine($"You are currently on [ {(steroidMedStr == "H" ? "Hydrocortisone" : "Prednisolone")} {steroidDose} mg ].");
Console.WriteLine("");// spacer

// PURPOSE
// store user-entered purpose to variable
char[] purposeOptions = { 'S', 'P' }; // Allowed options
char purpose = document.GetValidatedChoice("> Are you experiencing Symptoms or having a Procedure done? Type S for Symptoms or P for Procedure.", purposeOptions);
string purposeStr = Convert.ToString(purpose);

Console.WriteLine("\r\nChoose from the following options and type the corresponding letter:");

// store user-entered purpose to variable
char[] detailOptions = { 'F', 'C','D', 'E', 'P','M','J','S' }; // Allowed options
char detail;
string detailStr = "";

// If user typed in S for Symptoms:
if (purposeStr == "S")
{
    detail = document.GetValidatedChoice(@"F for Fever
C for Covid
D for Diarrhea/Vomiting 
E for Extremely Unwell 
P for Pregnancy", detailOptions);
    detailStr = Convert.ToString(detail);
}
// If user typed in P for Procedure:
else if (purposeStr == "P")
{
    detail =  document.GetValidatedChoice(@"M for Minor Dental Surgery
J for Major Dental Surgery
S for Surgery/Invasive Procedures", detailOptions);
    detailStr = Convert.ToString(detail);
}
;

// Store list of detail options to a Scenario structure
Scenario[] conditions =
        [
            new Scenario("F", "Fever"),
            new Scenario("C", "COVID"),
            new Scenario("D", "Diarrhea/Vomiting"),
            new Scenario("E", "Extremely Unwell"),
            new Scenario("P", "Pregnancy"),
            new Scenario("M", "Minor Dental Surgery"),
            new Scenario("J", "Major Dental Surgery"),
            new Scenario("S", "Surgery/Invasive Procedures")
        ];

// Find the condition
    bool found = false;
    string conditionQuery = "";
    foreach (var condition in conditions)
    {
        if (condition.Key == detailStr)
        {
            conditionQuery = condition.Value;
            Console.WriteLine($"\r\nYou would like to know your steroid dose for {conditionQuery}: \r\n");
            
            found = true;
        }
    }
    if (!found)
    {
        Console.WriteLine("Condition not found.");
    }

string advice = "";

// DOSAGE ADVICE
switch (steroidMedStr)
{   // Prednisolone SDR Advice
    case "P": 
        // Prednisolone dose for Fever
        if (steroidDose <= 10 && detailStr == "F")
        { // Prednisolone dose <= 10 mg
            advice = "Take 5 mg of Prednisolone twice daily.";
            document.DisplayText(advice);
        } 
        // Prednisolone dose > 10 mg
        else if (steroidDose > 10 && detailStr == "F")
        {
            advice = "Split daily dose of Prednisolone to twice daily.";
            document.DisplayText(advice);
        }
        // Prednisolone dose for Covid
        else if (steroidDose <= 10 && detailStr == "C")
        { // Prednisolone dose <= 10 mg
            advice = "Take 10 mg of Prednisolone twice daily.";
            document.DisplayText(advice);
        }
        // Prednisolone dose > 10 mg
        else if (steroidDose > 10 && detailStr == "C")
         {   
            advice = "Split daily dose of Prednisolone to twice daily, e.g. 20 mg daily - take 10 mg twice daily.";
            document.DisplayText(advice);
         }
        else if (detailStr == "D") // if Diarrhea/Vomiting
        {
            advice = "If you vomit once, take an extra 5 mg of Prednisolone.\r\n\r\n!!! If vomiting persists after you have taken the extra steroid dose, you must seek urgent medical attention: go to the Emergency Department, or call an ambulance via 999.!!!\r\n\r\nTake your NHS Steroid Emergency Card with you and ensure that the team looking after you know that you are on steroid medication and that you are at risk of adrenal crisis and may need a steroid injection.";
            document.DisplayText(advice);
        }   
        else if (detailStr == "E") // Extremely unwell
        {
            advice = "Take an extra 20 mg of Prednisolone and seek medical advice.";
            document.DisplayText(advice);
        }
        else if (detailStr == "M") // Minor Dental Surgery
        {
            advice = "Take 5 mg of Prednisolone one hour prior to procedure and take a double dose for 24 hours after the procedure, then return to your normal dose. ";
            document.DisplayText(advice);
        }
        break; // break for case "P"

    // Hydrocortisone SDR Advice
    case "H": 
        // Hydrocortisone dose for Fever
        if (steroidDose >= 10 && detailStr == "F")
        { // Hydrocortisone dose > 10 mg
            advice = "Take 20 mg of Hydrocortisone immediately, then 10 mg 6 hourly.";
            document.DisplayText(advice);
        }
        // Hydrocortisone dose >= 10 mg for Covid
        else if (steroidDose >= 10 && detailStr == "C")
        {
            advice = "Take 20 mg of Hydrocortisone every 6 hours.";
            document.DisplayText(advice);
        }
         // Hydrocortisone dose < 10 mg
        else if (steroidDose < 10)
        { 
            advice = "Double your current dose of Hydrocortisone for the duration of your illness. If it lasts < 7 days, you can switch back to your usual dose the day after. If it lasts > 7 days, seek advice from your clinician.";
            document.DisplayText(advice);
        }
        else if (detailStr == "D") // if Diarrhea/Vomiting
        {
            advice = "If you vomit once, take an extra 20 mg of Hydrocortisone by mouth.\r\n\r\n!!! If vomiting persists after you have taken the extra steroid dose, you must seek urgent medical attention: go to the Emergency Department, or call an ambulance via 999.!!!\r\n\r\nTake your NHS Steroid Emergency Card with you and ensure that the team looking after you know that you are on steroid medication and that you are at risk of adrenal crisis and may need a steroid injection.";
            document.DisplayText(advice);
        }
        else if (detailStr == "M") // Minor Dental Surgery
        {
            advice = "Take 20 mg of Hydrocortisone one hour prior to the procedure and take a double dose for 24 hours after the procedure, then return to your normal dose. ";
            document.DisplayText(advice);
        }
        else if (detailStr == "E") // Extremely unwell
        {
            advice = "Take an extra 50 mg of Hydrocortisone and seek medical advice.";
            document.DisplayText(advice);
        }
        break; // break for case "H"

    default:
        break;
} // closing switch steroidMedStr statement

// SDR advice applicable to both Prednisolone and Hydrocortisone
if (steroidMedStr == "P" || steroidMedStr == "H") // Either on Prednisolone/HC
{
    if (detailStr == "P") // Pregnancy
        {
            advice = "Carry on normal doses unless advised by your HCP.  At the onset of labour or start of a caesarean section, to start a continuous IV infusion of 200 mg Hydrocortisone over 24 hours (alternatively 50 mg of Hydrocortisone IV or IM every 6 hours). Double usual oral dose for 48 hours after the baby is born.";
            document.DisplayText(advice);
        }  
    else if (detailStr == "J") // Major Dental Surgery
    {
        advice = "You may need 100 mg of IM Hydrocortisone before major dental work anaesthesia - discuss in advance with your dentist. Take a double dose for 24 hours after any dental procedure, then return to your normal dose.";
        document.DisplayText(advice);
    }
    else if (detailStr == "S") // Surgery/Invasive Procedures
    {
        advice = "100 mg of Hydrocortisone by IV or IM injection at the start of surgery followed by a continuous IV infusion of 200 mg Hydrocortisone over 24 hours, or 50 mg of Hydrocortisone IV or IM every 6 hours. Double usual dose when eating and drinking and reduce to usual dose over the next 1-2 weeks as you recover.";
        document.DisplayText(advice);
    }    
}

// Write SDR note:
string? sickDayDose = $@"
STEROID SICK DAY RULES 
Patient: {firstName} {lastName} 
MRN: {mrn}

Steroid Medication: {(steroidMedStr == "H"? "HYDROCORTISONE" : "PREDNISOLONE")}
Daily dosage: {steroidDose} mg

Dosage Advice for: {conditionQuery.ToUpper()}

{advice}

***
What are the signs and symptoms of an adrenal crisis? 

Low blood pressure. Feeling dizzy or light-headed. Fever, shivering or feeling very cold. Nausea and /or vomiting. Feeling very weak. Extreme tiredness, drowsiness or confusion. Aching muscles and/or joints. Stomach ache. Severe diarrhoea. 

If you are unwell, make sure that the person treating you knows you are at risk of adrenal crisis and show them your NHS Steroid Emergency Card 

Resource: https://www.endocrinology.org/media/4169/ai-and-exogenous-steroids_patient-information-sheet.pdf

Generated on: {dateTime}
";

Console.WriteLine("\r\n*** SICK DAY RULE SUMMARY ***");
// Generate Sick Day Rule File
document.WriteToFile(sickDayDose, $"Sick Day Rule - {firstName} {lastName} | {mrn}.txt");

// RESTART PROGRAM OPTION
string? input;
do
{
    Console.Write("Do you want to restart the program? (Yes/No): ");
    input = Console.ReadLine()?.Trim().ToLower();
    // While user enters invalid input, display error prompt.
    if (input != "yes" && input != "no")
    {
        Console.WriteLine("Invalid input. Please type 'Yes' or 'No'.");
    }

} while (input != "yes" && input != "no");

    restart = (input == "yes"); // If user chooses 'Yes', restart program

    if (!restart) // If user chooses 'No', exit program
    {
        Console.WriteLine("Thank you for using the 'Sick Day Rule' Program. Goodbye!");
    }
} // End of While Loop
// PROGRAM END
