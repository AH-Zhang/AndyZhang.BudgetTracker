
export interface Income {
    id:          number;
    userId:      number;
    amount:      number;
    description: string;
    incomeDate:  string;
    remarks:     string;
}

export interface NewIncome {
    userId:      number;
    amount:      number;
    description: string;
    incomeDate:  string;
    remarks:     string;
}