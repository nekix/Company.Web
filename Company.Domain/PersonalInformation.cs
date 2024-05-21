using Company.Shared.Utilities;

namespace Company;

/// <summary>
/// Не относящиеся к компании персональные данные сотрудника.
/// </summary>
public sealed class PersonalInformation
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? Patronymic { get; private set; }

    public string FullName =>
        $"{LastName} {FirstName} {Patronymic}"
        .TrimEnd();

    public DateOnly BirthDate { get; private set; }

    #region Protected сonstructor only for ORM
    // Поле, не допускающее значения NULL, должно содержать значение,
    // отличное от NULL, при выходе из конструктора.
    // Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618
    // Новый защищенный элемент объявлен в запечатанном типе
#pragma warning disable CS0628
    protected PersonalInformation()
    {
        // Only for ORM
    }
#pragma warning restore CS0628
#pragma warning restore CS8618
    #endregion

    public PersonalInformation(
        string firstName,
        string lastName,
        string? patronymic,
        DateOnly birthDate)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetPatronymic(patronymic);
        SetBirthDate(birthDate);
    }

    #region Internal actions
    public string ChangeFirstName(string firstName)
    {
        SetFirstName(firstName);
        return FirstName;
    }

    public string ChangeLastName(string lastName)
    {
        SetLastName(lastName);
        return LastName;
    }

    public string ChangePatronymic(string patronymic)
    {
        Check.NotNull(
            patronymic,
            nameof(patronymic));

        SetPatronymic(patronymic);
        return Patronymic!;
    }

    public void DeletePatronymic()
    {
        SetPatronymic(null);
    }

    /// <summary>
    /// Изменить ФИО
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="patronymic"></param>
    /// <returns><see cref="FullName"/></returns>
    public string ChangeFullName(
        string firstName,
        string lastName,
        string? patronymic)
    {
        if (firstName != FirstName)
        {
            SetFirstName(firstName);
        }

        if (lastName != LastName)
        {
            SetLastName(lastName);
        }

        if (patronymic != Patronymic)
        {
            if (patronymic == null)
            {
                DeletePatronymic();
            }
            else
            {
                SetPatronymic(patronymic);
            }
        }

        return FullName;
    }

    public void RemovePatronymic()
    {
        SetPatronymic(null);
    }

    public DateOnly ChangeBirthDate(DateOnly birthDate)
    {
        SetBirthDate(birthDate);
        return BirthDate;
    }
    #endregion

    #region Private methods
    private void SetFirstName(string firstName)
    {
        FirstName = Check.NotNullOrWhiteSpace(
            firstName,
            nameof(firstName),
            minLength: PersonalInformationConsts
                .MinFirstNameLength,
            maxLength: PersonalInformationConsts
                .MaxFirstNameLength);
    }

    private void SetLastName(string lastName)
    {
        LastName = Check.NotNullOrWhiteSpace(
            lastName,
            nameof(lastName),
            minLength: PersonalInformationConsts
                .MinLastNameLength,
            maxLength: PersonalInformationConsts
                .MaxLastNameLength);
    }

    private void SetPatronymic(string? patronymic)
    {
        if (patronymic != null)
        {
            Patronymic = Check.NotNullOrWhiteSpace(
                patronymic,
                nameof(patronymic),
                minLength: PersonalInformationConsts
                    .MinPatronymicLength,
                maxLength: PersonalInformationConsts
                    .MaxPatronymicLength);
        }
        else
        {
            Patronymic = null;
        }
    }

    private void SetBirthDate(DateOnly birthDate)
    {
        BirthDate = Check.Range(
            birthDate,
            nameof(birthDate),
            new DateOnly(
                PersonalInformationConsts.MinBirthDate.Year,
                PersonalInformationConsts.MinBirthDate.Mounth,
                PersonalInformationConsts.MaxBirthDate.Day),
            PersonalInformationConsts.MaxBirthDate);
    }
    #endregion
}
