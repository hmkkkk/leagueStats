import './App.css'
import { getSummonerByNameAndRegion, updateSummoner } from './services/summonerService'

const App = () => {
  const name = "franz wurm"
  const region = "eune"

  const getSummoner = async () => {
    const summoner = await getSummonerByNameAndRegion({name, region})
    console.log(summoner)
  }

  const update = async () => {
    const summoner = await updateSummoner({name, region})
    console.log(summoner)
  }
 
  return (
    <>
      <button onClick={getSummoner}>getSummoner</button>
      <button onClick={update}>update</button>
    </>
  )
}

export default App
