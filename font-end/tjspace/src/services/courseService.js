// 获取评论 ！哈哈
import axios from "axios";
// import Qs from  'qs'
import { URL } from './config'

export async function getCourseInfo(payload) {
    console.log("in get courseInfo", payload)
    var resp = await axios.get(`${URL}Search/SearchCourseUnique`, {
        headers: {
            Authorization: payload.token,
        },
        params: {
            courseId: payload.courseId,
            teacherId: payload.teacherId,
        },
    });
    console.log("in get courseInfo response", resp);
    return resp.data;
}
