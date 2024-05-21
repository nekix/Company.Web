namespace Company;

public static class PersonalInformationConsts
{
    public const int MinFirstNameLength = 1;
    public const int MaxFirstNameLength = 100;

    public const int MinLastNameLength = 1;
    public const int MaxLastNameLength = 100;

    public const int MinPatronymicLength = 1;
    public const int MaxPatronymicLength = 100;

    public static class MinBirthDate
    {
        public const int Year = 1900;

        public const int Mounth = 1;

        public const int Day = 1;
    }

    public static readonly DateOnly MaxBirthDate = DateOnly.FromDateTime(DateTime.Now);
}
