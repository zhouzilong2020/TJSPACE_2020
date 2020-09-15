// 远程登录用户！哈哈
import axios from "axios";
import { URL } from "./config";

/**
 * 登录用户的API接口，如果成功返回token以及userId，并将token，userId保存在浏览器的localstorage中；
 * @param {Object} payload payload需要传入email，password
 */
export async function loginUser(payload) {
    console.log("in userSevice", payload);
    var resp = await axios.get(`${URL}Login/login`, {
        params: {
            email: payload.email,
            password: payload.password
        }
    });
    console.log(resp);
    // localStorage.setItem("token", resp.token);
    return resp.data
}

/**
 * 使用浏览器保存的userId和token来获取我是谁，如果token过期则清除本地保存的信息
 */
export async function whoAmI() {
    var token = localStorage.getItem("token");
    if (token != null) return token;
    return null;
}

/**
 * 退出登录，删除本地保存的token和userId信息
 */
export async function logoutUser() {
    localStorage.removeItem("token");
    return true
}

/**
 * 注册用户API，如果成功返回token以及userId，并将token，userId保存在浏览器的localstorage中；
 * @param {Object} payload payload需要传入 email，password，nickname，以及邮箱的相关验证码
 */
export async function registerUser(payload) {
    console.log(payload);
}

/**
 * 生成一个验证码
 */
function getCode(digit) {
    let min = Math.pow(10, digit);
    let max = min * 10;
    return Math.floor(Math.random() * (max - min - 1)) + min;
}
/**
 * 验证用户的邮箱信息
 * @param {Object} payload
 */
export async function sentAuthCode(payload) {
    console.log("in userSevice", payload);
    let code =
        "TJSPACE-" +
        getCode(3).toString() +
        "-" +
        getCode(3).toString() +
        "-" +
        getCode(3).toString();
    return code;
}

export async function getUserInfo(payload) {
    console.log(payload)
    var resp = await axios.get(`${URL}Show/user`, {
        headers: {
            Authorization: payload.token
        },
        params: {
            userId: payload.userId
        }
    });
    return resp.data.data[0];
}

/**
 * 获取用户收藏的课程信息
 * @param {Object} payload 
 */
export async function getFavoriteCourse(payload) {
    console.log(payload)
    var resp = await axios.get(`${URL}Show/getCollectedCourse`, {
        headers: {
            Authorization: payload.token
        },
        params: {
            userId: payload.userId
        }
    });
    return resp
}

