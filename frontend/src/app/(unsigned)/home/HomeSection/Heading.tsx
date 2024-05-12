import { ReactNode } from 'react';

interface HeadingProps {
    children: ReactNode;
}

export default function Heading({ children }: HeadingProps) {
    return (
        <h2 className="font-black lg:text-5xl text-green-300">{children}</h2>
    );
}
