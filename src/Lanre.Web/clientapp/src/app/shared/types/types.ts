export interface Book {
    id: string;
    name: string;
    series: string;
    authors: string;
    rating: string;
    sinopsis: string;
    imageUrl: string;
    url: string;
    pages: string;
    username: string;
    readed?: string[];
    selected: boolean;
}

export interface Window {
    location: any;
}

export interface Token {
    exp: number;
    iss: string;
}

export interface VoteList {
    id: string;
    userId: string;
    name: string;
    numberOfVotes: number;
    books: BookFromVoteList[];
}

export interface BookFromVoteList extends Book {
    votedBy?: string[];
}
