import { Guid } from 'guid-typescript';
import { UserInfo } from './UserInfo.model';

export class User{
    uid:Guid;
    username:string;
    password:string;
    userinfo:UserInfo;
}

