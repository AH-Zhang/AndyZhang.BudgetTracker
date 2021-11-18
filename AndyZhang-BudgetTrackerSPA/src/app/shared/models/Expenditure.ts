
export interface Expenditure {
    id:          number;
    userId:      number;
    amount:      number;
    description: string;
    expDate:     string;
    remarks:     string;
}

export interface NewExpenditure {
    userId:      number;
    amount:      number;
    description: string;
    expDate:     string;
    remarks:     string;
}