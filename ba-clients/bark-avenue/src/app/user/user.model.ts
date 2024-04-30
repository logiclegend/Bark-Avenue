export interface IUser {
    firstName: string;
    lastName: string;
    email: string;
    password?: string;
}

export interface IUserCredentials {
    email: string;
    password: string;
}

export interface IUserSignUpCredentials {
    name: string; 
    email: string;
    number: string;
    password: string;
    confirm_password: string;
}


