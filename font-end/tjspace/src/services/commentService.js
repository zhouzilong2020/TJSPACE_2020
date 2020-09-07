// 获取评论 ！哈哈
import axios from "axios";
import Qs from  'qs'
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
            courseId: payload.courseId,
        },
    });
    console.log("in getComment response", resp);
    return resp.data;
}

/**
 * 用户发表对课程评价的评价
 * @param {Object} payload userID, commentID, type(1 有用， 2 没用)
 */
export async function evaluateComment(payload) {
    console.log("in evaluate comment", payload)
    var resp = await axios.post(`${URL}Comment/EvaluateComment`,
        Qs.stringify({
            "commentId": payload.commentId,
            "userId": payload.userId,
            "type": payload.type
        }),
        {
            headers: { 
                Authorization: token,
                // 'Content-Type':'application/x-www-form-urlencoded'
            }
        },
    );
    console.log("in evaluate comment response", resp);
    return resp.data;
}

/**
 * 获取用户对当前课程评价的历史评价
 * @param {Object} payload 传入 userId， commentId 
 */
export async function getEvaluate(payload) {
    console.log("in getEvaluate ", payload)
    var resp = await axios.get(`${URL}Comment/CanEvaluate`, {
        headers: {
            Authorization: token,
        },
        params: {
            userId: payload.userId,
            commentId: payload.commentId,
        },
    });
    console.log("in getEvaluate response", resp);
    return resp.data;

}


/**
 * 取消评论
 * @param {Object} payload 传入 userId, commentId
 */
export async function cancelEvaluation(payload) {
    console.log("in cancel Evaluation ", payload)
    var resp = await axios.post(`${URL}Comment/CancelEvaluation`,
        {
            commentId: payload.commentId,
            userId: payload.userId,
        },
        {
            headers: { 
                Authorization: token,
                'Content-Type':'application/x-www-form-urlencoded' 
            }
        }
    );
    console.log("in getEvaluate response", resp);
    return resp.data;

}