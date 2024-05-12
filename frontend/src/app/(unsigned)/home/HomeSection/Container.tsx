import { ReactNode } from 'react';

interface ContainerProps {
    children: ReactNode;
}

export default function Container({ children }: ContainerProps) {
    return (
        <div className="flex justify-between gap-x-28 w-full">{children}</div>
    );
}
