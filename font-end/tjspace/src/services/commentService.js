// 获取评论 ！哈哈
import axios from "axios";
import { token, URL } from './config'
/**
 * 获取用户评论评论
 */
export async function getComment(payload) {
    console.log("in get comment", payload)
    var resp = await axios.get(`${URL}Show/comment`, {
        headers: {
            Authorization: token,
        },
        params: {
            courseID: payload.courseID,
        },
    });
    console.log("in getComment response", resp);
    return resp.data;
}

/**
 * 用户发表对课程评价的评价
 * @param {Object} payload userID, commentID, type(0 有用， 1没用)
 */
export async function evaluateComment(payload) {
    console.log("in evaluate comment", payload)
    var resp = await axios.get(`${URL}Comment/EvaluateComment`, {
        headers: {
            Authorization: token,
        },
        params: {
            userid: payload.courseID,
            commentid: payload.commentid,
            type: payload.type
        },
    });
    console.log("in evaluate comment response", resp);
    return resp.data;
}
