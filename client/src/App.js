function App() {

  var x = process.env;

  return (
    <div>
      hello world {process.env.REACT_APP_BASE_API_URL}
    </div>
  );
}

export default App;
