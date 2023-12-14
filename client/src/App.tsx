import './App.css'
import Content from './components/content'
import { GlobalProvider } from './context/GlobalState'

const App = () => {
  
  return (
    <GlobalProvider>
      <Content />
    </GlobalProvider>
  )
}

export default App
