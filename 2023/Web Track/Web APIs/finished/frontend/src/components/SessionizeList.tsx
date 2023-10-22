import { TabList, Tab } from "@fluentui/react-components";
import { Sessionize } from "../models/sessionize";
import { Dispatch, useState } from "react";
import { SessionList } from "./SessionList";

export const SessionizeList = ({
  data,
  selections,
  addSelection,
  removeSelection,
}: {
  data: Sessionize[];
  selections: string[];
  addSelection: Dispatch<string>;
  removeSelection: Dispatch<string>;
}) => {
  const [selectedDay, setSelectedDay] = useState(data[0]);
  return (
    <>
      <TabList selectedValue={selectedDay.groupId}>
        {data.map((sessionize, i) => {
          return (
            <Tab
              value={sessionize.groupId}
              key={sessionize.groupId}
              onClick={() => setSelectedDay(() => sessionize)}
            >
              Day {i + 1}
            </Tab>
          );
        })}
      </TabList>
      <SessionList
        day={selectedDay.sessions}
        selections={selections}
        addSelection={addSelection}
        removeSelection={removeSelection}
      />
    </>
  );
};
