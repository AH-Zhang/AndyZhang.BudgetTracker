import { Expenditure } from "./Expenditure";
import { Income } from "./Income";

export interface User {
    id:           number;
    email:        string;
    fullName:     string;
    joinedOn:     string;
    incomes:      Income[];
    expenditures: Expenditure[];
}

