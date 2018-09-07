
function Gn(props) {
    if(props.gn==0)return <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    else return <p>&nbsp;&nbsp;{props.gn}&nbsp;&nbsp;</p>
}

function Tdtype(props) {
  if(props.grid_id%3==0 && props.id%3==0){
    return <td className="redb1"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==1 && props.id%3==0){
    return <td className="redb2"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==2 && props.id%3==0){
    return <td className="redb3"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==0 && props.id%3==1){
    return <td className="redb4"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==2 && props.id%3==1){
    return <td className="redb6"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==0 && props.id%3==2){
    return <td className="redb7"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==1 && props.id%3==2){
    return <td className="redb8"><Gn gn={props.grid_number}/></td>
  }else if(props.grid_id%3==2 && props.id%3==2){
    return <td className="redb9"><Gn gn={props.grid_number}/></td>
  }
  else return <td><Gn gn={props.grid_number}/></td>
}

const Row = (props) => (
    <tr>
    {
      props.row.map(function(d){
        //return <td><Gn gn={d.grid_number}/>{props.id}</td>
        return <Tdtype grid_id={d.grid_id} grid_number={d.grid_number} id={props.id} />
      })
    }
    </tr>
)

const Sudo = (props) => (
    <table border="1">
    <tbody>
    {
      props.row.map(function(d,i){
        return <Row row={d} id={i} />
      })
    }
    </tbody>
    </table>
)

export default Sudo
