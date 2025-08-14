import React, { useState } from "react";
import CountContext from "./count";

export default function CountProvider({ children }) {
  const [count, setCount] = useState(0);

  const handleIncrement = () => {
    setCount((prev) => prev + 1);
  };
  // compound pattern
  return (
    <CountContext.Provider value={{ count, handleIncrement }}>
      {children}
    </CountContext.Provider>
  );
}
