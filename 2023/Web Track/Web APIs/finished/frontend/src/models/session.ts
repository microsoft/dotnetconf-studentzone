import { Speaker } from "./speaker";

export type Session = {
  id: string;
  title: string;
  description: string;
  startsAt: string;
  endsAt: string;
  speakers: Speaker[];
};
