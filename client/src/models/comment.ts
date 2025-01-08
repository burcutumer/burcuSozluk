import { User } from "./user";

export interface Comment {
    id: number,
    text: string,
    createdAt: string,
    user: User
}