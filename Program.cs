using System;
DateTime dateTime = DateTime.Now;

Console.WriteLine("Welcome to the 'Sick Day Rule' Program");

// ENTER USER DETAILS:
// Type your first name and press enter
Console.WriteLine("Enter your first name");
// store user-entered first name to variable
string? firstName = Console.ReadLine();

// Type your last name and press enter
Console.WriteLine("Enter your last name");
// store user-entered last name to variable
string? lastName = Console.ReadLine();

// Type your MRN and press enter
Console.WriteLine("Enter your MRN (if known)");
// store user-entered mrn to variable
string? mrn = Console.ReadLine();

// Print the user info
Console.WriteLine($"Hi, {firstName} {lastName}; MRN: {mrn}");
Console.WriteLine("Produce your own tailored Sick Day Rule dosage according to your current steroid medication. Follow the prompts below and answer accordingly.");

// MEDICATION
Console.WriteLine("> What steroid medication are you on? Type H for Hydrocortisone, P for Prednisolone");
// store user-entered steroid medication to variable
string? steroidMed = Console.ReadLine();

// Medication Dose
Console.WriteLine("> What daily dosage are you on? Enter number in mg");
// store user-entered steroid dose to variable
int? steroidDose = Convert.ToInt32(Console.ReadLine());

// Display user-entered steroid medication
Console.WriteLine($"You are currently on {(steroidMed == "H" ? "Hydrocortisone" : "Prednisolone")} {steroidDose} mg");

// PURPOSE
Console.WriteLine("> Are you experiencing Symptoms or having a Procedure done? Type P for Procedure, S for Symptoms");
// store user-entered purpose to variable
string? purpose = Console.ReadLine();

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
string? detail = Console.ReadLine();

Console.WriteLine($"You would like to know your steroid dose for: ");

// string ?questionPurpose = Console.ReadLine();

switch (detail)
{
    case "F":
        Console.WriteLine("Fever");
        break;
    case "C":
        Console.WriteLine("Covid");
        break;
    case "DV":
        Console.WriteLine("Diarrhea/Vomiting");
        break;
    case "E":
        Console.WriteLine("Extremely Unwell");
        break;
    case "P":
        Console.WriteLine("Pregnancy");
        break;
    case "MN":
        Console.WriteLine("Minor Dental Surgery");
        break;
    case "MJ":
        Console.WriteLine("Major Dental Surgery");
        break;
    case "S":
        Console.WriteLine("Surgery/Invasive Procedure");
        break;
} // closing tag for switch

// Purpose Summary - You would like to know your steroid dose for
// string ?purposeSummary = $"{questionPurpose} {purposeAnswer}";

switch (steroidMed)
{
    case "P": // Prednisolone
              // Prednisolone dose for Fever
              // Prednisolone dose <= 10 mg
        if (steroidDose <= 10 && detail == "F")
            Console.WriteLine("Take 5 mg twice daily");

        // Prednisolone dose > 10 mg
        else if (steroidDose > 10 && detail == "F")
            Console.WriteLine("Split daily dose to twice daily");

        // Prednisolone dose for Covid
        // Prednisolone dose <= 10 mg
        else if (steroidDose <= 10 && detail == "C")
            Console.WriteLine("Take 10mg twice daily");

        // Prednisolone dose > 10 mg
        else if (steroidDose > 10 && detail == "C")
            Console.WriteLine("Split daily dose to twice daily, e.g. 20 mg daily - take 10 mg twice daily");

        else if (detail == "DV") // if Diarrhea/Vomiting
            Console.WriteLine("If you vomit once, take an extra 5 mg of Prednisolone.  !!! If vomiting persists after you have taken the extra steroid dose, you must seek urgent medical attention: go to the Emergency Department, or call an ambulance via 999. !!! Take your NHS Steroid Emergency Card with you and ensure that the team looking after you know that you are on steroid medication and that you are at risk of adrenal crisis and may need a steroid injection. ");

        else if (detail == "E") // Extremely unwell
            Console.WriteLine("Take an extra 20mg of Prednisolone.");

        else if (detail == "P") // Pregnancy
            Console.WriteLine("carry on normal doses unless advised by your HCP.  At the onset of labour or start of a caesarean section, to start a continuous IV infusion of 200 mg Hydrocortisone over 24 hours (alternatively 50 mg of Hydrocortisone IV or IM every 6 hours). Double usual oral dose for 48 hours after the baby is born.  ");

        else if (detail == "MJ")
            Console.WriteLine("Take 5mg of Prednisolone one hour prior to procedure and take a double dose for 24 hours after the procedure, then return to your normal dose. ");

        else if (detail == "MN")
            Console.WriteLine("Take 5mg of Prednisolone one hour prior to procedure and take a double dose for 24 hours after the procedure, then return to your normal dose. ");

        // string ?predAdviceFeverCovid = Console.ReadLine();
        break; // break for case "P"

    case "H": // Hydrocortisone
              // Hydrocortisone dose for Fever
              // Hydrocortisone dose > 10 mg
        if (steroidDose > 10 && detail == "F")
            Console.WriteLine("Take 20 mg immediately, then 10 mg 6 hourly");
        // Hydrocortisone dose > 10 mg
        else if (steroidDose > 10 && detail == "C")
            Console.WriteLine("Take 20 mg every 6 hours");

        // string ?hcAdviceFeverCovid = Console.ReadLine();
        break; // break for case "H"

    default:
        break;
} // closing switch steroidMed statement

if (steroidMed == "P" || steroidMed == "H")
{
    if (detail == "F")
        Console.WriteLine("Take 20 mg every 6 hours");
    else if (detail == "C")
        Console.WriteLine("Take Hydrocortisone 20mg every 6 hours");
    else if (detail == "MJ")
        Console.WriteLine("You may need 100mg of IM Hydrocortisone before major dental work anaesthesia – discuss in advance with your dentist. Take a double dose for 24 hours after any dental procedure, then return to your normal dose.");
    else if (detail == "S")
        Console.WriteLine(" 100 mg of Hydrocortisone by IV or IM injection at the start of surgery followed by a continuous IV infusion of 200 mg Hydrocortisone over 24 hours, or 50 mg of Hydrocortisone IV or IM every 6 hours. Double usual dose when eating and drinking and reduce to usual dose over the next 1-2 weeks as you recover.");
    // string ?otherAdvice = Console.ReadLine();

}

 string ?advice = Console.ReadLine();

// Write SDR note:

string? sickDayDose = $@"
STEROID SICK DAY RULES 
Patient: {firstName} {lastName} 
MRN: {mrn}

Steroid Medication: {(steroidMed == "H"? "Hydrocortisone" : "Prednisolone")}
Daily dosage: {steroidDose} mg

Dosage Advice for: {detail}

{advice}

What are the signs and symptoms of an adrenal crisis? 
Low blood pressure. Feeling dizzy or light-headed. Fever, shivering or feeling very cold. Nausea and /or vomiting. Feeling very weak. Extreme tiredness, drowsiness or confusion. Aching muscles and/or joints. Stomach ache. Severe diarrhoea. 

Resource: https://www.endocrinology.org/media/4169/ai-and-exogenous-steroids_patient-information-sheet.pdf

Generated on: {dateTime}
";

GenereateFile newFile = new GenereateFile();

newFile.WriteToFile(sickDayDose, $"Sick Day Rule - {firstName} {lastName} | {mrn}.txt");
