// 获取评论 ！哈哈
import axios from "axios";
// import Qs from  'qs'
import { URL } from './config'

export async function getCourseInfo(payload) {
  console.log("in get courseInfo", payload)
  var resp = await axios.get(`${URL}Search/SearchCourseByCourseId`, {
      headers: {
          Authorization: payload.token,
      },
      params: {
          courseId: payload.courseId,
      },
  });
  console.log("in get courseInfo response", resp);
  return resp.data;
}
