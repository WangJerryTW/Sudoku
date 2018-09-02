import Link from 'next/link'

export default () =>
  <div>
    Hello world
    <p>scoped!</p>
    <Link href="/about">
      <a>here</a>
    </Link>
    <style>{`
      p {
        color: blue;
      }
      div {
        background: red;
      }
      @media (max-width: 600px) {
        div {
          background: blue;
        }
      }
    `}</style>
    <style>{`
      body {
        background: gray;
      }
    `}</style>
  </div>