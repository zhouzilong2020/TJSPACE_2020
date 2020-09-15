// 远程登录用户！哈哈
import axios from "axios";
import { URL } from "./config";

/**
 * 登录用户的API接口，如果成功返回token以及userId，并将token，userId保存在浏览器的localstorage中；
 * @param {Object} payload payload需要传入account{email，password}, remember
 */
export async function loginUser(payload) {
  console.log("in userSevice", payload.account);
  var resp = await axios.get(`${URL}Login/login`, {
    params: {
      email: payload.account.email,
      password: payload.account.password,
    },
  });
  console.log('in login service', resp);

  // 登录成功，用户选择记住账号
  if(resp.data.status && payload.remember){
    localStorage.setItem('TJSPACE-email', payload.account.email)
  }
  return resp.data;
}

/**
 * 使用浏览器保存的userId和token来获取我是谁，如果token过期则清除本地保存的信息
 */
export async function whoAmI() {
  
}

/**
 * 退出登录，删除本地保存的token和userId信息
 */
export async function logoutUser() {


  return true;
}

/**
 * 注册用户API，如果成功返回token以及userId，并将token，userId保存在浏览器的localstorage中；
 * @param {Object} payload payload需要传入 email，password，nickname，以及邮箱的相关验证码
 */
export async function registerUser(payload) {
  console.log("in userSevice", payload);
  var resp = await axios.post(`${URL}Register/register`, {},
    {
      headers: {
        Authorization: payload.token,
      },
      params: {
        email: payload.email,
        password: payload.password,
        nickname: payload.nickname,
      },
    }
  );
  console.log(resp);
  return resp.data;
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
 * 向用户的邮箱发送验证码
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
  var resp = await axios.get(`${URL}Register/email`, {
    params: {
      email: payload.email,
      code: code,
    },
  });
  console.log(resp);
  return resp;
}
/**
 *验证用户的邮箱信息 
 *@param {Object} payload
 */
// export async function verifyAuthCode(payload) {

// }

export async function getUserInfo(payload) {
  console.log(payload);
  var resp = await axios.get(`${URL}Show/user`, {
    headers: {
      Authorization: payload.token,
    },
    params: {
      userId: payload.userId,
    },
  });
  return resp.data.data[0];
}

/**
 * 获取用户收藏的课程信息
 * @param {Object} payload
 */
export async function getFavoriteCourse(payload) {
  console.log(payload);
  var resp = await axios.get(`${URL}Show/getCollectedCourse`, {
    headers: {
      Authorization: payload.token,
    },
    params: {
      userId: payload.userId,
    },
  });
  return resp;
}
