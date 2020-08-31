// 远程登录用户！哈哈
import axios from "axios";
import {URL} from './config'

/**
 * 登录用户的API接口，如果成功返回token以及userID，并将token，userid保存在浏览器的localstorage中；
 * @param {Object} payload payload需要传入email，password
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

/**
 * 使用浏览器保存的userID和token来获取我是谁，如果token过期则清除本地保存的信息
 */
export async function whoAmI(){

}

/**
 * 退出登录，删除本地保存的token和userID信息
 */
export async function logoutUser(){

}

/**
 * 注册用户API，如果成功返回token以及userID，并将token，userid保存在浏览器的localstorage中；
 * @param {Object} payload payload需要传入 email，password，nickname，以及邮箱的相关验证码
 */
export async function registerUser(payload){
    
}