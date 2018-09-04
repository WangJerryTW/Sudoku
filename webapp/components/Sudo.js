
function Gn(props) {
    if(props.gn==0)return <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    else return <p>&nbsp;&nbsp;{props.gn}&nbsp;&nbsp;</p>
}

const Row = (props) => (
    <tr>
    {
      props.row.map(function(d){
        return <td><Gn gn={d.grid_number}/></td>
      })
    }
    </tr>
)

const Sudo = (props) => (
    <table border="1">
    <tbody>
    {
      props.row.map(function(d){
        return <Row row={d} />
      })
    }
    </tbody>
    </table>
)

export default Sudo
