// 获取评论 ！哈哈
import axios from "axios";
/**
 * 获取用户评论评论
 */
export async function getComment(payload) {
    console.log("in get comment", payload);
    var resp = await axios.get("http://175.24.115.240:8080/api/Show/comment", {
            headers:{
                Authorization: payload.token,
            },
            params:{
                courseID: payload.courseID,
            },
    });
    console.log(resp.data);
    return resp.data;
}

