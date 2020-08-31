// 远程登录用户！哈哈
import axios from "axios";
import {URL} from './config'
/**
 * 登录用户
 */
export async function loginUser(payload) {
    console.log("in userSevice", payload)
    var resp = await axios.get(`${URL}Login/login`, {
            params:{
                email : payload.email,
                password : payload.password,
            },
    });
    console.log(resp)
    // localStorage.setItem("token", resp.token);
    return resp.data;
}

export async function whoAmI(){

}

export async function logoutUser(){

}

export async function registerUser(){
    
}