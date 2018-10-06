<template>
  <div>
    <h1 style="text-align:center">數獨遊戲 - 後台</h1>
    <div style="text-align:center"><router-link to="/">返回首頁</router-link></div>
    
    <div style="text-align:center" v-if="!login">
        <br>
        輸入密碼：<input type="password" v-model="password">
        &nbsp;&nbsp;
        <button v-on:click="submit()">確認</button>
    </div>
    
    <div v-else>
        <div style="font-size:22px;font-weight:bold;">
            <a href="#!" @click="add">新增數獨</a>
            &nbsp;&nbsp;
            <a href="#!" @click="logout">登出</a>
        </div>
        <div v-if="mode=='list'">
            <ul>
                <li v-for="item in sudolist" :key="item.id">
                    <router-link :to="'sudoku/'+item.id">{{ item.id }}</router-link>&nbsp;&nbsp;
                    <span v-if="item.tag==1">very easy</span>
                    <span v-else-if="item.tag==2">easy</span>
                    <span v-else-if="item.tag==3">medium</span>
                    <span v-else-if="item.tag==4">hard</span>
                    <span v-else-if="item.tag==5">very hard</span>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="#!" @click="edit(item.id)">編輯</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="#!" @click="del(item.id)">刪除</a>
                </li>
            </ul>
        </div>
        <div v-else>
            <center>
                <h3 v-if="mode=='edit'">正在編輯{{sudo_id}}</h3>
                <select v-model="sudo.tag">
                    <option value="1">Very easy</option>
                    <option value="2">easy</option>
                    <option value="3">Medium</option>
                    <option value="4">Hard</option>
                    <option value="5">Very hard</option>
                </select>
                <table>
                  <tr v-for="row in sudo.row" :key="row.id">
                      <td v-for="item in row" :key="item.id" :class="[item.type,'qcolor']" @click="clicktd(item)">
                          {{ item.grid_number==0?'&nbsp;&nbsp;':item.grid_number }}<br>
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
                <button  @click="clean_num()">清除數字</button>&nbsp;&nbsp;
                <button @click="save">儲存</button>&nbsp;&nbsp;
                <button @click="mode='list'">返回列表</button>
            </center>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Admin',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      login:false,
      password: '',
      mode: 'list',
      sudolist:[],
      sudo:[],
      select_number:[],
      select_grid_id:0,
      tag:1,
      sudo_id:0
    }
  },
  created () {
    this.axios.get('http://api.pureday.life/sudo/')
      .then(response => (this.sudolist = response.data))
    var self = this
    //墊資料
    this.axios.get('http://api.pureday.life/sudo/1')
      .then(function (response) {
          self.sudo = response.data
          self.inittd(1)
          self.init_zero()
    })
    for(var i=1;i<=9;i++){
      this.select_number.push({type:'not-active-select',number:i})
    }
  },
  methods: {
      clicktd (item) {
          this.inittd(false)
          this.initsn()
          this.select_grid_item = item
          this.check_grid(item)
      },
      select (item) {
          if(item.type==='not-active-select')return
          this.change_number(item.number)
          this.check_grid(this.select_grid_item)
      },
      clean_num () {
        this.change_number(0)
        this.initsn()
        this.check_grid(this.select_grid_item)
      },
      submit () {
          if( this.password === '1234'){
              this.login = true
          }else{
              alert('密碼錯誤')
          }
      },
      logout () {
          this.login = false
      },
      add () {
        this.mode = 'add'
        this.init_zero()
      },
      async edit (id) {
          this.mode = 'edit'
          this.sudo_id = id
          this.init_zero()
          let res = await this.axios.get('sudo/'+id)
          this.sudo = res.data
          this.inittd(1)
      },
      save () {
        var fstr = '';
        for(var i in this.sudo.row){
          for(var j in this.sudo.row[i]){
            fstr += this.sudo.row[i][j].grid_number + '-'
          }
        }
        fstr = fstr.slice(0, -1);
        
        var self = this
        this.axios({
              method: 'post',
              url: 'sudo/',
              data: {action:this.mode,tag:this.sudo.tag,fstr:fstr,sudo_id:this.sudo_id},
              headers: {
                'Content-Type': 'text/plain;charset=utf-8',
              },
          }).then(function (res) {
              if(res.data){
                  if(self.mode=='add'){
                    alert('新增成功')
                  }else{
                      alert('更新成功')
                  }
                  self.axios.get('sudo/').then(function (response) {
                      self.sudolist = response.data
                      self.mode = 'list'
                  })
              }
          })
      },
      del (id) {
          var self = this
          this.axios({
              method: 'post',
              url: 'sudo/',
              data: {action:'del',id:id},
              headers: {
                'Content-Type': 'text/plain;charset=utf-8',
              },
          }).then(function (res) {
              if(res.data){
                  alert('刪除成功')
                  self.axios.get('sudo/').then(function (response) {
                      self.sudolist = response.data
                      self.mode = 'list'
                  })
              }
          })
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
      init_zero () {
          if(this.sudo.length === 0)return
          this.sudo.row.forEach(function(row){
              for(var i in row){
                  row[i].grid_number = 0
              }
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
      initsn(){
        this.select_number.forEach(function(item){
          item.type = 'active-select'
        })
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
      }
  }
}
</script>

<style>
  li{
    padding:5px;
    font-size:22px;
  }
  a{
    color:white;
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
    cursor:pointer;
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
</style>
