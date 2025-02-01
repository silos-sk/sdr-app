DateTime dateTime = DateTime.Now;

Console.WriteLine("Welcome to the 'Sick Day Rule' Program");

// ENTER USER DETAILS:
// Type your first name and press enter
Console.WriteLine("Enter your first name:");
// store user-entered first name to variable
string? firstName = Console.ReadLine();

// Type your last name and press enter
Console.WriteLine("Enter your last name:");
// store user-entered last name to variable
string? lastName = Console.ReadLine();

// Type your MRN and press enter
Console.WriteLine("Enter your MRN (if known)");
// store user-entered mrn to variable
string? mrn = Console.ReadLine();

// Print the user info
Console.WriteLine($"Hi, {firstName} {lastName}; MRN: {mrn}");
Console.WriteLine("Produce your own tailored Sick Day Rule dosage according to your current steroid medication. Follow the prompts below and answer accordingly.");
Console.WriteLine("");

// MEDICATION
Console.WriteLine("> What steroid medication are you on? Type H for Hydrocortisone, P for Prednisolone");
// store user-entered steroid medication to variable
#pragma warning disable CS8602 // Dereference of a possibly null reference.
string? steroidMed = Console.ReadLine().ToUpper();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

// Medication Dose
Console.WriteLine("> What daily dosage are you on? Enter number in mg");
// store user-entered steroid dose to variable
int? steroidDose = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("");
// Display user-entered steroid medication
Console.WriteLine($"You are currently on {(steroidMed == "H" ? "Hydrocortisone" : "Prednisolone")} {steroidDose} mg");
Console.WriteLine("");

// PURPOSE
Console.WriteLine("> Are you experiencing Symptoms or having a Procedure done? Type P for Procedure, S for Symptoms");
// store user-entered purpose to variable

string? purpose = Console.ReadLine()?.Trim().ToUpper(); // Normalize input

if (purpose == "S")
{
    Console.WriteLine(@"F for Fever
C for Covid
DV for Diarrhea/Vomiting 
E for Extremely Unwell 
P for Pregnancy");
}
else if (purpose == "P")
{
    Console.WriteLine(@"MN for Minor Dental Surgery
MJ for Major Dental Surgery
S for Surgery/Invasive Procedures");
}
;

string? detail = Console.ReadLine()?.Trim().ToUpper(); // Normalize input

Scenario[] conditions =
        [
            new Scenario("F", "Fever"),
            new Scenario("C", "Covid"),
            new Scenario("DV", "Diarrhea/Vomiting"),
            new Scenario("E", "Extremely Unwell"),
            new Scenario("P", "Pregnancy"),
            new Scenario("MN", "Minor Dental Surgery"),
            new Scenario("MJ", "Major Dental Surgery"),
            new Scenario("S", "Surgery/Invasive Procedures")
        ];

// Find the condition
    bool found = false;
    string conditionQuery = "";
    foreach (var condition in conditions)
    {
        if (condition.Key == detail)
        {
            conditionQuery = condition.Value;
            Console.WriteLine($"You would like to know your steroid dose for {conditionQuery}");
            
            found = true;
        }
    }
    if (!found)
    {
        Console.WriteLine("Condition not found.");
    }

string advice = "";
Document displayAdvice = new Document ();
switch (steroidMed)
{
    case "P": // Prednisolone
              // Prednisolone dose for Fever
              // Prednisolone dose <= 10 mg
        if (steroidDose <= 10 && detail == "F")
        {
            advice = "Take 5 mg twice daily";
            displayAdvice.DisplayText(advice);
        } 
        // Prednisolone dose > 10 mg
        else if (steroidDose > 10 && detail == "F")
        {
            advice = "Split daily dose to twice daily";
            displayAdvice.DisplayText(advice);
        }

        // Prednisolone dose for Covid
        // Prednisolone dose <= 10 mg
        else if (steroidDose <= 10 && detail == "C")
        {
            advice = "Take 10mg twice daily";
            displayAdvice.DisplayText(advice);
        }
        // Prednisolone dose > 10 mg
        else if (steroidDose > 10 && detail == "C")
         {   
            advice = "Split daily dose to twice daily, e.g. 20 mg daily - take 10 mg twice daily";
            displayAdvice.DisplayText(advice);
         }

        else if (detail == "DV") // if Diarrhea/Vomiting
        {
            advice = "If you vomit once, take an extra 5 mg of Prednisolone.  !!! If vomiting persists after you have taken the extra steroid dose, you must seek urgent medical attention: go to the Emergency Department, or call an ambulance via 999. !!! Take your NHS Steroid Emergency Card with you and ensure that the team looking after you know that you are on steroid medication and that you are at risk of adrenal crisis and may need a steroid injection. ";
            displayAdvice.DisplayText(advice);
        }
            
        else if (detail == "E") // Extremely unwell
        {
            advice = "Take an extra 20mg of Prednisolone.";
            displayAdvice.DisplayText(advice);
        }
            
        else if (detail == "P") // Pregnancy
        {
            advice = "Carry on normal doses unless advised by your HCP.  At the onset of labour or start of a caesarean section, to start a continuous IV infusion of 200 mg Hydrocortisone over 24 hours (alternatively 50 mg of Hydrocortisone IV or IM every 6 hours). Double usual oral dose for 48 hours after the baby is born.  ";
            displayAdvice.DisplayText(advice);
        }
        
        else if (detail == "MJ")
        {
            advice = "Take 5mg of Prednisolone one hour prior to procedure and take a double dose for 24 hours after the procedure, then return to your normal dose. ";
            displayAdvice.DisplayText(advice);
        }

        else if (detail == "MN")
            Console.WriteLine("Take 5mg of Prednisolone one hour prior to procedure and take a double dose for 24 hours after the procedure, then return to your normal dose. ");
            displayAdvice.DisplayText(advice);

        break; // break for case "P"

    case "H": // Hydrocortisone
              // Hydrocortisone dose for Fever
              // Hydrocortisone dose > 10 mg
        if (steroidDose > 10 && detail == "F")
        {
            advice = "Take 20 mg immediately, then 10 mg 6 hourly";
            displayAdvice.DisplayText(advice);
        }
        // Hydrocortisone dose > 10 mg
    
        else if (steroidDose > 10 && detail == "C")
        {
            advice = "Take 20 mg every 6 hours.";
            displayAdvice.DisplayText(advice);
        }

        break; // break for case "H"

    default:
        break;
} // closing switch steroidMed statement

if (steroidMed == "P" || steroidMed == "H")
{
    if (detail == "MJ")
    {
        advice = "You may need 100mg of IM Hydrocortisone before major dental work anaesthesia – discuss in advance with your dentist. Take a double dose for 24 hours after any dental procedure, then return to your normal dose.";
        displayAdvice.DisplayText(advice);
    }
    else if (detail == "S")
    {
        advice = " 100 mg of Hydrocortisone by IV or IM injection at the start of surgery followed by a continuous IV infusion of 200 mg Hydrocortisone over 24 hours, or 50 mg of Hydrocortisone IV or IM every 6 hours. Double usual dose when eating and drinking and reduce to usual dose over the next 1-2 weeks as you recover.";
        displayAdvice.DisplayText(advice);
    }    
}

// Write SDR note:

string? sickDayDose = $@"
STEROID SICK DAY RULES 
Patient: {firstName} {lastName} 
MRN: {mrn}

Steroid Medication: {(steroidMed == "H"? "Hydrocortisone" : "Prednisolone")}
Daily dosage: {steroidDose} mg

Dosage Advice for: {conditionQuery}

{advice}

What are the signs and symptoms of an adrenal crisis? 
Low blood pressure. Feeling dizzy or light-headed. Fever, shivering or feeling very cold. Nausea and /or vomiting. Feeling very weak. Extreme tiredness, drowsiness or confusion. Aching muscles and/or joints. Stomach ache. Severe diarrhoea. 

Resource: https://www.endocrinology.org/media/4169/ai-and-exogenous-steroids_patient-information-sheet.pdf

Generated on: {dateTime}
";

Document newFile = new Document();

newFile.WriteToFile(sickDayDose, $"Sick Day Rule - {firstName} {lastName} | {mrn}.txt");
