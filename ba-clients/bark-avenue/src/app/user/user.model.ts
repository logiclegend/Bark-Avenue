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
    username: string; 
    email: string;
    phone_number: string;
    password_user: string;
    confirm_password: string;
}


