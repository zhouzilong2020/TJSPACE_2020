// 远程登录用户！哈哈
import axios from "axios";
/**
 * 登录用户
 */
export async function loginUser() {
    var resp = await axios.get("http://175.24.115.240:8080/api/Login/login", {
            params:{
                email:'111',
                password:'111',
            },
    });
    return resp.data;
}