import { ReactNode } from 'react';

interface ContainerProps {
    children: ReactNode;
}

export default function Container({ children }: ContainerProps) {
    return <div className="mt-14 space-y-10">{children}</div>;
}
