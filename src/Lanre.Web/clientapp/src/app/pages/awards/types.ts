import { BookFromVoteList } from '@/app/shared/types/types'

export interface BookForVote extends BookFromVoteList {
    selected: boolean;
    readedByMe?: boolean;
    blocked?: boolean;
}
