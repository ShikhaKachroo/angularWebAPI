import { Guid } from 'guid-typescript';

export class UserProfile{
    upid:Guid;
    skills :string;
    experience:number;
    company:string;
    certificate:string;
    resume:string;
    uiid:Guid;
}