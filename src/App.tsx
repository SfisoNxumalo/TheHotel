import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css'
import LoadingComponent from './components/LoadingComponent/LoadingComponent'
import SplashPage from './app/pages/SplashPage/SplashPage';
import RoomService from './app/pages/RoomServicePage/RoomService';
import Dashboard from './app/pages/DashboardPage/Dashboard';

const queryClient = new QueryClient()

function App() {

  return (
    <>
     <QueryClientProvider client={queryClient}>
      <BrowserRouter>
      <Routes>
        {/* <Route path="/" element={<Navbar />}> */}
          <Route index element={<Dashboard/>} />
          {/* <Route path="Dashboard" element={<Dashboard />} /> */}
           {/*<Route path="contact" element={<Contact />} /> */}
          <Route path="*" element={<RoomService/>} />
        {/* </Route> */}
      </Routes>
    </BrowserRouter>
    </QueryClientProvider>
    </>
  )
}

export default App
