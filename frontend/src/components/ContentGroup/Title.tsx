import { ReactNode } from 'react';

interface TitleProps {
    children: ReactNode;
}

export default function Title({ children }: TitleProps) {
    return <h1 className="text-green-300 text-4xl font-black">{children}</h1>;
}
