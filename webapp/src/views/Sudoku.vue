<template>
  <div>
    <h1 style="text-align:center"><router-link to="/">數獨遊戲</router-link></h1>
    <center>
      <table>
          <tr v-for="row in sudo.row" :key="row.id">
              <td v-for="item in row" :key="item.id" :class="[item.type,'qcolor']" v-if="item.ques" style="cursor:context-menu;">
                  {{item.grid_number}}<br>
              </td>
              <td v-else :class="[item.type,'acolor']" v-on:click="clicktd(item)">
                {{ item.grid_number==0?"&nbsp;":item.grid_number }}<br>
              </td>
          </tr>
      </table>
      <br>
      <table>
        <tr>
          <td v-for="item in select_number" :key="item.id" :class="[item.type,'qcolor']" @click="select(item)">{{ item.number }}</td>
        </tr>
      </table>
      <br>
      <table>
        <tr>
          <td class="active-select" @click="clean_num()">清除數字</td>
          <td class="active-select" @click="clean()">清除選擇</td>
          <td class="active-select" @click="restart()">重新開始</td>
        </tr>
      </table>
      使用時間：{{ second }}&nbsp;&nbsp;&nbsp;&nbsp;<button @click="controll_time()">{{ time_compute?'暫停':'繼續' }}</button>
    </center>
  </div>
</template>

<script>
export default {
  name: 'Index',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      sudo:[],
      select_number:[],
      select_grid_id:0,
      select_grid_item:[],
      second:0,
      timer:[],
      time_compute:false
    }
  },
  async created () {
    let res = await this.axios.get('sudo/'+this.$route.params.id)
    this.sudo = res.data
    this.inittd(true)
    for(var i=1;i<=9;i++){
      this.select_number.push({type:'not-active-select',number:i})
    }
  },
  methods:{
      clicktd (item) {
          this.inittd(false)
          this.initsn()
          this.select_grid_item = item
          this.check_grid(item)
          if(!this.time_compute){
            this.start_time()
            this.time_compute = true
          }
      },
      select (item) {
        if(item.type==='not-active-select')return
        this.change_number(item.number)
        this.check_grid(this.select_grid_item)
        if(this.check_finish()){
          this.controll_time()
          alert('好啦好啦很厲害啦！\n一共花了'+this.second+'秒。')
        }
      },
      clean () {
        this.inittd(false)
      },
      clean_num () {
        this.change_number(0)
        this.initsn()
        this.check_grid(this.select_grid_item)
      },
      restart () {
        this.second = 0
        this.time_compute = false
        clearInterval(this.timer)
        this.inittd(2)
      },
      inittd(type){
        this.sudo.row.forEach(function(row,k){
            var row_id = k
            for(var i in row){
                if((row_id%9 >= 0 && row_id%9 <= 2 || row_id%9 >= 6 && row_id%9 <= 8)
                    && (row[i].grid_id%9 >= 0 && row[i].grid_id%9 <= 2 || row[i].grid_id%9 >= 6 && row[i].grid_id%9 <= 8)){
                    row[i].type = 'graytd'
                }else if((row_id%9 >= 3 && row_id%9 <= 5) && (row[i].grid_id%9 >= 3 && row[i].grid_id%9 <= 5)){
                    row[i].type = 'graytd'
                }else row[i].type = 'whitetd'
                row[i].row_id = row_id
                row[i].selected = false
                if(type==1){
                  if(row[i].grid_number!=0){
                    row[i].ques = true
                  }else{
                    row[i].ques = false
                  }
                }else if(type==2){
                  if(!row[i].ques){
                    row[i].grid_number = 0
                  }
                }
            }
        })
        var a = this.sudo.row[0][0].grid_number
        this.sudo.row[0][0].grid_number = 5
        this.sudo.row[0][0].grid_number = a
      },
      initsn(){
        this.select_number.forEach(function(item){
          item.type = 'active-select'
        })
      },
      change_number(number){
        for(var i in this.sudo.row){
          for(var j in this.sudo.row[i]){
            if(this.sudo.row[i][j].grid_id===this.select_grid_id){
              this.sudo.row[i][j].grid_number = number
              return
            }
          }
        }
      },
      check_grid(item){
        var col = item.grid_id%9
          var irow_id = item.row_id
          var max_col,min_col,max_row,min_row
          if(col>=0 && col<=2){
            max_col = 2
            min_col = 0
          }else if(col>=3 && col<=5){
            max_col = 5
            min_col = 3
          }else if(col>=6 && col<=8){
            max_col = 8
            min_col = 6
          }
          if(irow_id>=0 && irow_id<=2){
            max_row = 2
            min_row = 0
          }else if(irow_id>=3 && irow_id<=5){
            max_row = 5
            min_row = 3
          }else if(irow_id>=6 && irow_id<=8){
            max_row = 8
            min_row = 6
          }
          var self = this;
          this.sudo.row.forEach(function(row,k){
            var row_id = k,n=0
            for(var i in row){
                if(row[i].grid_id%9==col || row_id == irow_id){
                    row[i].type='shallow-yellowtd'
                    if(row[i].grid_number!=0){
                      n = row[i].grid_number -1
                      self.select_number[n].type = 'not-active-select'
                    }
                }
                if(row[i].grid_id%9>=min_col && row[i].grid_id%9<=max_col &&
                  row_id>=min_row && row_id<=max_row){
                  row[i].type='shallow-yellowtd'
                  if(row[i].grid_number!=0){
                    n = row[i].grid_number -1
                    self.select_number[n].type = 'not-active-select'
                  }
                }
            }
          })
          item.type='yellowtd'
          this.select_grid_id = item.grid_id
      },
      check_finish(){
        for(var i in this.sudo.row){
          for(var j in this.sudo.row[i]){
            if(this.sudo.row[i][j].grid_number==0){
              return false
            }
          }
        }
        return true
      },
      start_time(){
        this.timer = setInterval(() => {
          this.second++
        }, 1000)
      },
      controll_time(){
        if(this.time_compute){
          clearInterval(this.timer)
        }else{
          this.start_time()
        }
        this.time_compute = !this.time_compute
      }
  },
  computed: {
    category: function() {
      return this.sudo;
    },
  }
}
</script>

<style>
  li{
    padding:5px;
    font-size:22px;
  }
  .graytd{
    background-color:#c0c0c0;
  }
  .whitetd{
    background-color:white;  
  }
  .shallow-yellowtd{
    background-color:#fff887;
  }
  .yellowtd{
      background-color:yellow;
  }
  .qcolor{
    color:blue;
  }
  .acolor{
    color:black;
    cursor:pointer
  }
  .active-select{
    background-color:white;
    color:blue;
    cursor:pointer
  }
  .not-active-select{
    background-color:gray;
    color:#b7b7b7;
    cursor:context-menu;
  }
  table {
      border-collapse: collapse;
  }
  table, th, td {
    padding:10px 12px;
    border: 4px solid #354242;
  }
  @media (max-width: 576px) { 
    table, th, td {
      padding:5px 8px;
      border: 2px solid #354242;
    }
  }
</style>
