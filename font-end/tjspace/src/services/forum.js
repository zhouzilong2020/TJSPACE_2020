import axios from "axios";
import store from "../store/userInfo"
import {
    URL
} from "./config";
import {
    Loading,
    Notify
} from 'quasar'
var isLoading = 0
var timer
const cancelToken = axios.CancelToken
const source = cancelToken.source();
function SetLoading(){
    if (isLoading == 0) {
        Loading.show()
        timer = setTimeout(()=>{
            if(isLoading>0){
                Notify.create({
                    message: '请求超时，请重试',
                    position: 'center',
                    timeout: '2000'
                })
                source.cancel()
            }
        },5000) 
    }
    isLoading++;
}
function UnsetLoading(){
    isLoading--;
    if (isLoading == 0) {
        Loading.hide()
        isLoading = 0
        if (timer != void 0) {
            clearTimeout(timer)
            Loading.hide()
            timer = void 0
        }
    }
}
export function get(api, params) {
    SetLoading()
    return new Promise((resolve) => {
        axios.get(`${URL}` + api, {
            cancelToken :source.token,
            headers: {
                Authorization: store.state.token
            },
            params: params
        }).then(response => {
            resolve(response.data);
            UnsetLoading();
        }).catch(()=> {
            UnsetLoading();
        })
    })
}
export function post(api, params) {
    SetLoading()
    return new Promise((resolve) => {
        axios.post(`${URL}` + api, {}, {
            cancelToken :source.token,
            headers: {
                Authorization: store.state.token
            },
            params: params
        }).then(response => {
            resolve(response.data);
            UnsetLoading();
        }).catch(() => {
            UnsetLoading();
        })
    })
}

export function requestCancel(){
    if(isLoading>0){
        source.cancel()
    }
    clearTimeout(timer)
    timer = void 0
}