import Link from 'next/link'
import fetch from 'isomorphic-unfetch'
import Sudo from '../components/Sudo'

function Easylabel(props) {
  if(props.tag==1)return <p>Very easy</p>;
  if(props.tag==2)return <p>Easy</p>;
  if(props.tag==3)return <p>Medium</p>;
  if(props.tag==4)return <p>Hard</p>;
  if(props.tag==5)return <p>Very hard</p>;
}

const Index = (props) => (
  <div className="layout">
    <h1>數獨遊戲</h1>
    {
      props.sudo.map(function(a){
        return (
          <div>
            <h4>{a.id}</h4>
            <Easylabel tag={a.tag} />
            <Sudo row={a.row} />
          </div>
        )
      })
    }
    <style>{`
      .layout {
        margin: auto;
        width: 30%;
      }
      h3 {
        text-align:center;
      }
      body {
        background-color:#b5d1ff
      }
    `}</style>
  </div>
)

Index.getInitialProps = async function() {
  const res = await fetch('http://api.pureday.life/sudo/')
  const data = await res.json()

  console.log(`Show data fetched. Count: ${data.length}`)

  return {
    sudo: data
  }
}


export default Index