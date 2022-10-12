import { dateTimeLocaleOptions } from "../CONST/DateTimeLocaleOptions";

export const dateTimeStringToLocaleDateTime = (dateTime) => {
    return new Date(dateTime).toLocaleString("en-US", dateTimeLocaleOptions);
}
