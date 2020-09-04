// 获取评论 ！哈哈
import axios from "axios";
/**
 * 获取用户评论评论
 */
export async function getComment(payload) {
    console.log("in get comment", payload)
    var token = 'Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjkzNTMwMzY3ZDI0OTFiMzQ0MTEzODYwZGUyN2QzNzdlIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1OTkxODU2ODIsImV4cCI6MTU5OTE4OTI4MiwiaXNzIjoiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAiLCJhdWQiOlsiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAvcmVzb3VyY2VzIiwiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQyIiwic3ViIjoiMTExIiwiYXV0aF90aW1lIjoxNTk5MTg1NjgyLCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxIl0sImFtciI6WyJjdXN0b20iXX0.bSIL7WDtl_WUSqGRhiF5qbh1M9Vrfh1O1PP5Jj1jzVjGC9e_bicp7l_cj9ANPqgP_n6ZuwfHK5Mz2h17n5azOqqRKmWNT8X3r3E1-rjrdC8SJxwwpU2jtWfx0hqLCyn1oXxLIt8ZdkOuuuRSW7mpeHvCxP8IfMFQlQ0huHKrMLVtsOl2CDTOi4Za-oK-bWozMer8gxz-SfH-L3H5iP1a3PurQZCeuMnOatrbLJ1AhhW1E7A16rbbF47Z-HQ-3crkPnIDuRmrB-8R71Lm_Zbra8AXKLaJIrnz6KblD_wWB2fvoe99kfHarYAjOwMKKnSVsFiL8V-046VfC-FRAbm4cg'
    
    var resp = await axios.get("http://175.24.115.240:8080/api/Show/comment", {
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

