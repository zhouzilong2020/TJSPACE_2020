import axios from "axios";
import { token, URL } from './config'
export async function makeComment(payload){ 
 var resp=await axios.post(`${URL}Comment/PostComment`,{
    headers:{
        authorization:token,
    },
    params:{
        commentid: payload.commentid,
        conent: payload.content,
        teaching: payload.teaching,
        grade: payload.grade,
        homework: payload.homework,
        midterm: payload.midterm,
        final: payload.final,
        quiz: payload.quiz,
        assignment: payload.assignment,
        essay: payload.essay,
        project: payload.project,
        attendence: payload.attendence,
        reading: payload.reading,
        presentation: payload.presentation,
        overall: payload.overall,
        instructor: payload.instructor,
        grading: payload.grading,
        workload: payload.workload,
        date: payload.date,
        usefelnum: 0,
        uselessnnum: 0,
        userid: payload.userid,
        anonymous: 1,
        courseid: payload.courseid,
        teacherid: payload.teacherid,
    }
   });
   console.log("in makecomment response",resp);
   return resp.data;

}