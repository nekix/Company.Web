using System.ComponentModel.DataAnnotations;

namespace Company;

public class CreateUpdatePersonalInfoDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(
        maximumLength: PersonalInformationConsts.MaxFirstNameLength,
        MinimumLength = PersonalInformationConsts.MinFirstNameLength)]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(
        maximumLength: PersonalInformationConsts.MaxLastNameLength,
        MinimumLength = PersonalInformationConsts.MinLastNameLength)]
    public string LastName { get; set; }

    [StringLength(
        maximumLength: PersonalInformationConsts.MaxPatronymicLength,
        MinimumLength = PersonalInformationConsts.MinPatronymicLength)]
    public string? Patronymic { get; set; }

    [Required]
    // TODO: Аттрибут для валидации даты
    public DateOnly BirthDate { get; set; }
}