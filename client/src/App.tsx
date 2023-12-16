import './App.css'
import Content from './components/content'
import HomePage from './components/Home/homePage'
import Root from './components/root'
import SummonerPage from './components/Summoner/summonerPage'
import { GlobalProvider } from './context/GlobalState'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'

const router = createBrowserRouter ([
  {
    path: '/',
    element: <Root />,
    children: [
      {
        index: true,
        element: <HomePage />
      },
      {
        path: 'testPage',
        element: <Content />
      },
      {
        path: ':region/:name',
        element: <SummonerPage />
      }
    ]
  },
])

const App = () => {
  
  return (
    <GlobalProvider>
      <RouterProvider router={router} />
    </GlobalProvider>
  )
}

export default App
