// 获取评论 ！哈哈
import axios from "axios";
import {token, URL} from './config'
/**
 * 获取用户评论评论
 */
export async function getComment(payload) {
    console.log("in get comment", payload)
    var resp = await axios.get(`${URL}Show/comment`, {
            headers:{
                Authorization: token,
            },
            params:{
                courseID: payload.courseID,
            },
    });
    console.log("in service",resp);
    return resp.data;
}

