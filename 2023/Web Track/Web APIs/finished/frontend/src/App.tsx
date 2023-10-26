import { useEffect, useState } from "react";
import type { Sessionize } from "./models/sessionize";
import "./App.css";
import { Spinner } from "@fluentui/react-components";
import { SessionizeList } from "./components/SessionizeList";

enum DataLoadState {
  NotLoaded,
  Loading,
  Loaded,
  Error,
}

function App() {
  const [data, setData] = useState<Sessionize[]>([]);
  const [dataLoadState, setDataLoadState] = useState(DataLoadState.NotLoaded);
  const [selections, setSelections] = useState<string[]>([]);

  const addSelection = (sessionId: string) =>
    setSelections((current) => [...current, sessionId]);
  const removeSelection = (sessionId: string) =>
    setSelections((current) => current.filter((id) => id !== sessionId));

  useEffect(() => {
    const abortController = new AbortController();

    const fetchData = async () => {
      setDataLoadState(DataLoadState.Loading);

      try {
        const [sessionsResponse, selectionsResponse] = await Promise.all([
          fetch("/api/sessions", {
            signal: abortController.signal,
          }),
          fetch("/api/user/selections", {
            signal: abortController.signal,
          }),
        ]);

        const data = await sessionsResponse.json();
        setData(data);

        const selectionData = await selectionsResponse.json();
        setSelections(selectionData);
        setDataLoadState(DataLoadState.Loaded);
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
      } catch (error: any) {
        if (error.name === "AbortError") {
          console.log("Fetch aborted");
        } else {
          console.error(error);
        }
        setDataLoadState(DataLoadState.Error);
      }
    };

    fetchData();

    return () => {
      abortController.abort();
    };
  }, []);

  useEffect(() => {
    const abortController = new AbortController();

    if (dataLoadState !== DataLoadState.Loaded) {
      return;
    }

    const postData = async () => {
      const response = await fetch("/api/user/selections", {
        method: "POST",
        body: JSON.stringify(selections),
        headers: {
          "Content-Type": "application/json",
        },
        signal: abortController.signal,
      });

      if (!response.ok) {
        console.error("Error saving selections");
      }
    };

    postData();

    return () => {
      abortController.abort();
    };
  }, [selections, dataLoadState]);

  return (
    <>
      <main>
        <h1>.NET Conf Session Picker</h1>
        {(dataLoadState === DataLoadState.NotLoaded ||
          dataLoadState === DataLoadState.Loading) && <Spinner />}
        {dataLoadState === DataLoadState.Loaded && (
          <SessionizeList
            data={data}
            selections={selections}
            addSelection={addSelection}
            removeSelection={removeSelection}
          />
        )}
      </main>
    </>
  );
}

export default App;
