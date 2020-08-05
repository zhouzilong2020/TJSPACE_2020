<template>
  <div class="course-review-statistics">
		<p>{{courseStatistic.reveiwCnt}} Reviews</p>
		<ul class="rating-container">
			<li><strong>课程内容</strong><span class="rating rating-1">{{courseStatistic.content}}</span></li>
			<li><strong>教学</strong><span class="rating rating-3">{{courseStatistic.teaching}}</span></li>
			<li><strong>评分</strong><span class="rating rating-3">{{courseStatistic.grading}}</span></li>
			<li><strong>课程工作量</strong><span class="rating rating-4">{{courseStatistic.workload}}</span></li>
		</ul>
		

	</div>
</template>

<script>
export default {
    name:"CourseStatistic",
    props:{
        courseStatistic:{
            type: Object,

            default: function(){
                return{
                    reveiwCnt:100,
                    content:"A",
                    teaching:"A",
                    grading:"A",
                    workload:"A",
                }
            }
        }
    },


}
</script>

<style>

.course-review-statistics .rating-container li .rating {
    width: 50px;
    font-size: 22px;
    line-height: 35px;
    margin-top: 30px;
    border-radius: 6px;
}

.rating-container li .rating {
    display: inline-block;
    width: 20px;
    line-height: 20px;
    color: #fff;
    font-weight: 700;
    font-size: 12px;
    margin: 0;
    border-radius: 4px;
}

.course-review-statistics {
    padding: 14px 10px 8px;
    margin-bottom: 12px;
    border: 1px solid #ddd;
    border-radius: 8px;
    overflow: hidden;
    background: #fafafa;
}

.course-review-statistics > p {
    text-align: center;
    font-size: 24px;
    font-weight: 700;
    color: #036;
    margin-bottom: 5px;
    line-height: 34px;
}

.course-review-statistics .rating-container {
    width: 100%;
    text-align: center;
}

.rating-container {
    padding: 0;
    overflow: hidden;
}

.rating-1 {
    background: #fb1420;
}
.rating-2 {
    background: #ff7800;
}

.rating-3 {
    background: #ffba00;
}

.rating-4 {
    background: #afc732;
}


</style>