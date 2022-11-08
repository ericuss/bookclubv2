import { Book } from '@/app/shared/types/types'

export interface BookForVote extends Book {
    selected: boolean;
}
