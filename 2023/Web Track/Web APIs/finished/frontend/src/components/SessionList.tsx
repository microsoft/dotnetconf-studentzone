import { Button, Divider } from "@fluentui/react-components";
import { Calendar24Regular } from "@fluentui/react-icons";
import dayjs from "dayjs";
import localizedFormat from "dayjs/plugin/localizedFormat";
import timezone from "dayjs/plugin/timezone";
import utc from "dayjs/plugin/utc";
import type { Session } from "../models/session";
import { Dispatch } from "react";

dayjs.extend(utc);
dayjs.extend(timezone);
dayjs.extend(localizedFormat);

const formatDate = (time: string, tz = "PST") =>
  dayjs.tz(time, "PST").tz(tz).format("ll");

const formatTime = (time: string, tz = "PST") => {
  return dayjs.tz(time, "PST").tz(tz).format("LT");
};

const localTimeZone = dayjs.tz.guess();

const Session = ({
  session,
  selections,
  addSelection,
  removeSelection,
}: {
  session: Session;
  selections: string[];
  addSelection: Dispatch<string>;
  removeSelection: Dispatch<string>;
}) => {
  const isSelected = selections.includes(session.id);

  return (
    <>
      <div>
        <h2>{session.title}</h2>
        <h3>{session.speakers.map((speaker) => speaker.name).join(", ")}</h3>
        <p>{session.description}</p>
        <p>
          <time>
            {formatDate(session.startsAt)} {formatTime(session.startsAt)} -{" "}
            {formatTime(session.endsAt)} (PST)
          </time>
        </p>
        <p style={{ paddingBottom: "10px" }}>
          <time>
            {formatDate(session.startsAt, localTimeZone)}{" "}
            {formatTime(session.startsAt, localTimeZone)} -{" "}
            {formatTime(session.endsAt, localTimeZone)} (Local -{" "}
            {localTimeZone.split("/")[1]})
          </time>
          {isSelected ? (
            <Button
              style={{ float: "right" }}
              appearance="secondary"
              icon={<Calendar24Regular />}
              onClick={() => removeSelection(session.id)}
            >
              Remove from watch list
            </Button>
          ) : (
            <Button
              style={{ float: "right" }}
              appearance="primary"
              icon={<Calendar24Regular />}
              onClick={() => addSelection(session.id)}
            >
              Add to watch list
            </Button>
          )}
        </p>
      </div>

      <Divider />
    </>
  );
};

export const SessionList = ({
  day,
  selections,
  addSelection,
  removeSelection,
}: {
  day: Session[];
  selections: string[];
  addSelection: Dispatch<string>;
  removeSelection: Dispatch<string>;
}) => {
  return (
    <>
      {day.map((session) => (
        <Session
          key={session.id}
          session={session}
          selections={selections}
          addSelection={addSelection}
          removeSelection={removeSelection}
        />
      ))}
    </>
  );
};
