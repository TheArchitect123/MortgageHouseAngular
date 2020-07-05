export class StringHelper {
  public static isEmpty(str): boolean {
    return !str || 0 === str.length;
  }

  static existValueInEnum(type: any, value: any): boolean {
    return (
      Object.keys(type)
        .filter((k) => isNaN(Number(k)))
        .filter((k) => type[k] === value).length > 0
    );
  }

  static isBirthYearValid(year: number): boolean {
    return year >= 1923 && year <= new Date().getFullYear();
  }
}
