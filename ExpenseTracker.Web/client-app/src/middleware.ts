// middleware.ts
import { auth } from "@/lib/auth";
import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";

export async function middleware(request: NextRequest) {
    const session = await auth();

    // Protect /dashboard and everything under it
    if (request.nextUrl.pathname.startsWith("/dashboard")) {
        if (!session) {
            return NextResponse.redirect(new URL("/api/auth/signin", request.url));
        }
    }

    return NextResponse.next();
}

export const config = {
    matcher: ["/dashboard/:path*"], // Only run for these routes
};
