import BisAbuelo from "./components/bis-abuelo";
import CountProvider from "./contexts/count-provider";

function App() {
  return (
    <>
      <CountProvider>
        <BisAbuelo />
      </CountProvider>
    </>
  );
}

export default App;
