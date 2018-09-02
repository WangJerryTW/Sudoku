import Link from 'next/link'

export default () =>
  <div>
    <h3>Hello haha world</h3>
    <center>
      <Link href="/about">
        <a>about</a>
      </Link>
    </center>
    <style>{`
      h3 {
        text-align:center;
      }
      body {
        background-color:#b5d1ff
      }
    `}</style>
  </div>